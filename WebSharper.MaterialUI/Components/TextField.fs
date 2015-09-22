namespace WebSharper.MaterialUI

open WebSharper
open WebSharper.JavaScript

open WebSharper.React
open WebSharper.React.Bindings

[<JavaScript>]
type TextField(label, ?value, ?wide) =
    [<Inline "MaterialUI.TextField">]
    let class' () = X<ReactClass>

    member val Events = [] with get, set

    interface Component with
        member this.Map () =
            React.CreateElement(class' (), 
                New [
                    yield! [
                        "floatingLabelText" => label
                        "fullWidth"         => default' wide false
                    ]
                    match value with
                    | Some value ->
                        yield "value" => value
                    | _ ->
                        ()

                    yield! this.Events
                ])
