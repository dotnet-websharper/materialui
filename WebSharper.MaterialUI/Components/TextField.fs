namespace WebSharper.MaterialUI

open System.Collections

open WebSharper
open WebSharper.JavaScript

open WebSharper.React.Bindings

[<AutoOpen>]
[<JavaScript>]
module TextField =
    
    [<Inline "MaterialUI.TextField">]
    let internal Class = X<ReactClass>

    type TextField(label : string, ?value : string, ?wide) =
        inherit Component(Class)

        member val Properties =
            Generic.List [
                yield! [
                    "floatingLabelText" => label
                    "fullWidth"         => default' wide false
                ]
                match value with
                | Some value ->
                    yield "value" => value
                | _ ->
                    ()
            ]
