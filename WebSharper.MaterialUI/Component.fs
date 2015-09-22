namespace WebSharper.MaterialUI

open WebSharper
open WebSharper.JavaScript

open WebSharper.React.Bindings

[<AbstractClass>]
[<JavaScript>]
type EventListener() =
    let events = ref []

    member this.AddEvent (event : string * (SyntheticEvent -> unit)) =
        events := event :: !events
        this

    member this.GetEvents () = events
