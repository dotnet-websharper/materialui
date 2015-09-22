namespace WebSharper.MaterialUI

open WebSharper
open WebSharper.JavaScript

open WebSharper.React
open WebSharper.React.Bindings

[<JavaScript>]
type Checkbox(?label, ?state) =
    [<Inline "MaterialUI.Checkbox">]
    let class' () = X<ReactClass>

    member val Events = [] with get, set

    interface Component with
        member this.Map () =
            React.CreateElement(class' (), 
                New [
                    yield "label" => default' label ""
                    yield "defaultChecked" => default' state false

                    yield! this.Events
                ])
