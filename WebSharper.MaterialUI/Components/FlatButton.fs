namespace WebSharper.MaterialUI

open System.Collections

open WebSharper
open WebSharper.JavaScript

open WebSharper.React.Bindings

[<AutoOpen>]
[<JavaScript>]
module FlatButton =
    
    [<Inline "MaterialUI.FlatButton">]
    let internal Class = X<ReactClass>

    type FlatButton(label : string, ?disabled) =
        inherit Component(Class)

        member val Properties =
            Generic.List [
                "label"    => label
                "disabled" => default' disabled false
            ]
