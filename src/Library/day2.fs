namespace Library
module day2 =
    open shared
    printfn "Reading files for day 2!"
    let fullPath = getFilePath "input2"
    let solve: string =
        let lines = System.IO.File.ReadLines(fullPath)
        Seq.iter (fun line -> printfn "%s" line) lines
        printfn "Files read, solving"
        "Not solved yet lol"
