namespace WebSharper.React.Tests

open WebSharper
open WebSharper.JavaScript

[<JavaScript>]
module Document =
    
    [<Inline "document.body">]
    let Body = X<Dom.Element>
