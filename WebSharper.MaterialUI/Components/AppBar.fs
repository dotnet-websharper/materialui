namespace WebSharper.MaterialUI

open System.Collections

open WebSharper
open WebSharper.JavaScript

open WebSharper.React.Bindings

[<AutoOpen>]
[<JavaScript>]
module AppBar =
    
    [<Inline "MaterialUI.AppBar">]
    let internal Class = X<ReactClass>

    type AppBar(?title, ?depth) =
        inherit Component(Class)

        member val Properties =
            Generic.List [
                "title"  => default' title ""
                "zDepth" => default' depth 1
            ]
