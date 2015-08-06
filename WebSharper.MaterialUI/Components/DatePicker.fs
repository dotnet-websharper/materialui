namespace WebSharper.MaterialUI

open System.Collections

open WebSharper
open WebSharper.JavaScript

open WebSharper.React.Bindings

[<AutoOpen>]
[<JavaScript>]
module DatePicker =
    
    [<Inline "MaterialUI.DatePicker">]
    let internal Class = X<ReactClass>

    type DatePicker(?defaultDate, ?formatter) =
        inherit Component(Class)

        member val Properties =
            Generic.List [
                match defaultDate with
                | Some (date : Date) ->
                    yield "defaultDate" => date
                | _ ->
                    ()

                match formatter with
                | Some (func : Date -> string) ->
                    yield "formatData" => func
                | _ ->
                    ()
            ]
