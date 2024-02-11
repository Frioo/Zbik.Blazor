using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Zbik.Blazor.JsonTree.Models
{
    public class Node
    {
        public int Id { get; set; }
        public int Layer { get; set; }
        public string Name { get; set; }
        public string? Value { get; set; }
        public JsonValueKind ValueKind { get; set; }
        public IEnumerable<Node>? Children { get; set; }
        public bool HasChildren => Children != null && Children.Any();
        public bool IsArray => ValueKind == JsonValueKind.Array;

        public Node(JsonElement element, string? name, int layer = 0, int id = 0)
        {
            Id = id;
            Layer = layer;
            Name = name ?? id.ToString();
            ValueKind = element.ValueKind;

            switch (element.ValueKind)
            {
                case JsonValueKind.Undefined:
                case JsonValueKind.Null:
                {
                    Value = null;
                    Children = null;
                    break;
                }

                case JsonValueKind.True:
                case JsonValueKind.False:
                case JsonValueKind.Number:
                case JsonValueKind.String:
                {
                    Value = element.ToString();
                    Children = null;
                    break;
                }

                case JsonValueKind.Array:
                {
                    Value = null;
                    Children = element
                        .EnumerateArray()
                        .Select((el, i) => new Node(el, null, layer+1, i));
                    break;
                }

                case JsonValueKind.Object:
                {
                    Value = null;
                    Children = element
                        .EnumerateObject()
                        .Select((el, i) => new Node(el.Value, el.Name, layer + 1, i));
                    break;
                }
            }
            Id = id;
        }
    }
}
