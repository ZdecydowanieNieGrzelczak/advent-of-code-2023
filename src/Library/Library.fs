namespace Library

module Solve =
    open System
    let currentDay: string = "2";

    let solve (day: Option<string>): string =
        let newDay = 
            match day with
                | Some x -> x
                | None -> currentDay
        match newDay with
            | "1" -> day1.solve
            | "2" -> day2.solve
            | _ -> raise <| NotImplementedException()

        

