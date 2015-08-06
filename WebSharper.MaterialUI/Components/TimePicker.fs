namespace WebSharper.MaterialUI

open System.Collections

open WebSharper
open WebSharper.JavaScript

open WebSharper.React.Bindings

[<AutoOpen>]
[<JavaScript>]
module TimePicker =
    
    [<Inline "MaterialUI.TimePicker">]
    let internal Class = X<ReactClass>

    type TimePicker(?defaultTime) =
        inherit Component(Class)

        member val Properties =
            Generic.List [
                match defaultTime with
                | Some (time : Date) ->
                    yield "defaultTime" => time
                | _ ->
                    ()
            ]
