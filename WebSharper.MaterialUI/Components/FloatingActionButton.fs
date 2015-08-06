namespace WebSharper.MaterialUI

open System.Collections

open WebSharper
open WebSharper.JavaScript

open WebSharper.React.Bindings

[<AutoOpen>]
[<JavaScript>]
module FloatingActionButton =
    
    [<Inline "MaterialUI.FloatingActionButton">]
    let internal Class = X<ReactClass>

    type FloatingActionButton(icon : string, ?disabled) =
        inherit Component(Class)

        member val Properties =
            Generic.List [
                "iconClassName" => icon
                "disabled"      => default' disabled false
            ]
