namespace WebSharper.MaterialUI

open WebSharper
open WebSharper.JavaScript

open WebSharper.React
open WebSharper.React.Bindings

[<JavaScript>]
type RaisedButton(label, ?disabled, ?wide) =
    [<Inline "MaterialUI.RaisedButton">]
    let class' () = X<ReactClass>

    member val Events = [] with get, set

    interface Component with
        member this.Map () =
            React.CreateElement(class' (), 
                New [
                    yield "label"     => label
                    yield "disabled"  => default' disabled false
                    yield "fullWidth" => default' wide false

                    yield! this.Events
                ])
