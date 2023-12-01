open System
open Library.Solve
// For more information see https://aka.ms/fsharp-console-apps
printfn "Hello from F#"



[<EntryPoint>]
let main(args) =    
    printfn "args: %A" args
    printfn "Result: %s" (solve (Array.tryHead args))
    
    0
