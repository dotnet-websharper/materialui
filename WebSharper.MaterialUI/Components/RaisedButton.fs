namespace WebSharper.MaterialUI

open System.Collections

open WebSharper
open WebSharper.JavaScript

open WebSharper.React.Bindings

[<AutoOpen>]
[<JavaScript>]
module RaisedButton =
    
    [<Inline "MaterialUI.RaisedButton">]
    let internal Class = X<ReactClass>

    type RaisedButton(label : string, ?disabled, ?wide) =
        inherit Component(Class)

        member val Properties =
            Generic.List [
                "label"     => label
                "disabled"  => default' disabled false
                "fullWidth" => default' wide false
            ]
