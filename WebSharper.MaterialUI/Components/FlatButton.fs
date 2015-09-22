namespace WebSharper.MaterialUI

open WebSharper
open WebSharper.JavaScript

open WebSharper.React
open WebSharper.React.Bindings

[<JavaScript>]
type FlatButton(label, ?disabled) =
    [<Inline "MaterialUI.FlatButton">]
    let class' () = X<ReactClass>

    interface Component with
        member this.Map () =
            React.CreateElement(class' (), 
                New [
                    "label"    => label
                    "disabled" => default' disabled false
                ])
