# Zbik.Blazor.JsonTree
A tree view component for JSON data.  

## Parameters
**Data source options**  

|Name|Type|Description|
|----|----|-----------|
|Json|string|JSON string to use as data source|
|Object|object|C# object to use as data source|
|Document|JsonDocument|Parsed JSON document to use as data source|

**Display options**  

|Name|Type|Description|
|----|----|-----------|
|Expand|boolean|Expand tree branches|
|ShowArrayIndices|boolean|Display array indices for array children|
|ThemeClass|string|CSS class name to override tree styles|

## Usage

Page.razor
1. Set an interactive render mode for your page
```
@rendermode InteractiveServer
```
2. Define your data as an object or fetch some JSON from an API
```csharp
var data = new
{
    Foo = "Bar",
    Arr = new string[]
    {
        "One", "Two", "Three",
    },
    IsCool = true
};
```
3. Display your tree
```razor
@* Object data source *@
<Tree Data="@data" Expand="true" />

@* JSON string data source *@
<Tree Json="@json" Expand="true" />
```