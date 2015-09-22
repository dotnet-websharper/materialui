namespace WebSharper.MaterialUI

open WebSharper
open WebSharper.JavaScript

open WebSharper.React
open WebSharper.React.Bindings

[<JavaScript>]
type DatePicker(?defaultDate, ?formatter) =
    [<Inline "MaterialUI.DatePicker">]
    let class' () = X<ReactClass>

    interface Component with
        member this.Map () =
            React.CreateElement(class' (), 
                New [
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
                ])
