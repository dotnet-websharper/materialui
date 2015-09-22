namespace WebSharper.MaterialUI

open WebSharper
open WebSharper.JavaScript

open WebSharper.React
open WebSharper.React.Bindings

[<JavaScript>]
type TimePicker(?defaultTime) =
    [<Inline "MaterialUI.TimePicker">]
    let class' () = X<ReactClass>

    interface Component with
        member this.Map () =
            React.CreateElement(class' (), 
                New [
                    match defaultTime with
                    | Some (time : Date) ->
                        yield "defaultTime" => time
                    | _ ->
                        ()
                ])
