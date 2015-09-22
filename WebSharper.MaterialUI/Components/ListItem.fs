namespace WebSharper.MaterialUI

open WebSharper
open WebSharper.JavaScript

open WebSharper.React
open WebSharper.React.Bindings

[<JavaScript>]
type ListItem(?primaryText, ?secondaryText) =
    [<Inline "MaterialUI.ListItem">]
    let class' () = X<ReactClass>

    member val Checkbox = None with get, set

    interface Component with
        member this.Map () =
            React.CreateElement(class' (), 
                New [
                    yield "primaryText"        => default' primaryText ""
                    yield "secondaryText"      => default' secondaryText ""
                    yield "secondaryTextLines" => 2
                    
                    match this.Checkbox with
                    | Some checkbox ->
                        yield "leftCheckbox" => (checkbox :> Component).Map()
                    | _ ->
                        ()
                ])

    static member WithCheckbox state (callback : (SyntheticEvent -> unit)) (listItem : ListItem) =    
        let checkbox = Checkbox(state = state)

        checkbox.Events <- [ ("onCheck", box callback) ]
        
        listItem.Checkbox <- Some checkbox
        listItem
