namespace WebSharper.MaterialUI

open System.Collections

open WebSharper
open WebSharper.JavaScript

open WebSharper.React.Bindings
open WebSharper.React

[<AutoOpen>]
[<JavaScript>]
module Checkbox =
    
    type Event =
        | Check of (SyntheticEvent -> unit)

        interface GenericEvent with
            override this.ToString () =
                match this with
                | Check _ -> "onCheck"

    [<Inline "MaterialUI.Checkbox">]
    let internal Class = X<ReactClass>

    type Checkbox(?label, ?state) =
        inherit Component(Class)

        member val Properties =
            Generic.List [
                "label" => default' label ""
                "defaultChecked" => default' state false
            ]

    let Default =
        Checkbox()
