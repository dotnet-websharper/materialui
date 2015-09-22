namespace WebSharper.MaterialUI

open WebSharper
open WebSharper.JavaScript

open WebSharper.React
open WebSharper.React.Bindings

[<JavaScript>]
type List(?header, ?children : Component list) =
    [<Inline "MaterialUI.List">]
    let class' () = X<ReactClass>

    interface Component with
        member this.Map () =
            let children =
                default' children []
                |> List.map (fun child -> child.Map())
                |> List.toArray
            
            React.CreateElement(class' (), 
                New [
                    "subheader" => default' header ""
                ], children)
