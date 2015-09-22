namespace WebSharper.MaterialUI

open WebSharper
open WebSharper.JavaScript

open WebSharper.React
open WebSharper.React.Bindings

[<JavaScript>]
type ToolbarGroup(children : Component list, ?position : string) =
    [<Inline "MaterialUI.ToolbarGroup">]
    let class' () = X<ReactClass>

    interface Component with
        member this.Map () =
            React.CreateElement(class' (), 
                let children =
                    children
                    |> List.map (fun child -> child.Map())
                    |> List.toArray
                
                New [
                    match position with
                    | Some position ->
                        yield "float" => position
                    | _ ->
                        ()
                ], children)

[<JavaScript>]
type Toolbar(groups : ToolbarGroup list) =
    [<Inline "MaterialUI.Toolbar">]
    let class' () = X<ReactClass>

    interface Component with
        member this.Map () =
            let children =
                groups
                |> List.map (fun group -> (group :> Component).Map())
                |> List.toArray
            
            React.CreateElement(class' (), [], children)

[<JavaScript>]
type ToolbarSeparator() =
    [<Inline "MaterialUI.ToolbarSeparator">]
    let class' () = X<ReactClass>

    interface Component with
        member this.Map () =
            React.CreateElement (class' ())

[<JavaScript>]
type ToolbarTitle(text : string) =
    [<Inline "MaterialUI.ToolbarTitle">]
    let class' () = X<ReactClass>

    interface Component with
        member this.Map () =
            React.CreateElement(class' (), 
                New [
                    "text" => text
                ])
