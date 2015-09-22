namespace WebSharper.MaterialUI

open WebSharper
open WebSharper.JavaScript

open WebSharper.React
open WebSharper.React.Bindings

[<JavaScript>]
type Tabs(tabs : Tab list) =
    [<Inline "MaterialUI.Tabs">]
    let class' () = X<ReactClass>

    interface Component with
        member this.Map () =
            let children =
                tabs
                |> List.map (fun tab -> (tab :> Component).Map())
                |> List.toArray

            React.CreateElement(class' (), [], children)
