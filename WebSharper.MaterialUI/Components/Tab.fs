namespace WebSharper.MaterialUI

open WebSharper
open WebSharper.JavaScript

open WebSharper.React
open WebSharper.React.Bindings

[<JavaScript>]
type Tab(label, children : Component list) =
    [<Inline "MaterialUI.Tab">]
    let class' () = X<ReactClass>

    interface Component with
        member this.Map () =
            let children =
                children
                |> List.map (fun child -> child.Map())
                |> List.toArray
            
            React.CreateElement(class' (), 
                New [
                    "label" => label
                ], children)
