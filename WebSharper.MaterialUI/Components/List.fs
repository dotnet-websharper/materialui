namespace WebSharper.MaterialUI

open System.Collections

open WebSharper
open WebSharper.JavaScript

open WebSharper.React.Bindings

[<AutoOpen>]
[<JavaScript>]
module List =
    
    [<Inline "MaterialUI.List">]
    let internal Class = X<ReactClass>

    type List(?header, ?children) =
        inherit Component(Class, ?children = children)

        member val Properties =
            Generic.List [
                "subheader" => default' header ""
            ]
