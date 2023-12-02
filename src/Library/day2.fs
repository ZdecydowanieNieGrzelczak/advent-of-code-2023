namespace Library
module day2 =
    open shared

    let maxRed = 12
    let maxGreen = 13
    let maxBlue = 14

    let isTokenValid (token: string) =
        let tokens = token.Split(" ")
        match tokens[1] with
        | "green" -> (tokens[0] |> int) <= maxGreen
        | "red" -> (tokens[0] |> int) <= maxRed
        | "blue" -> (tokens[0] |> int) <= maxBlue
        | _ -> printfn "Bad Token: %s" tokens[1]; failwith "Bad parsing of tokens!"

    let isGameValid (game: string) =
        let trimmedTokens = game.Split(",") |> Array.map(fun x -> x.Trim())
        Array.forall isTokenValid trimmedTokens         

    let isLineValid (line: string) =
        let games = line.Split ";"
        Array.forall isGameValid games

    let checkLine (line: string) =
        let tokens = line.Split ":"
        let gameNumber = tokens[0].Trim().Split(" ")[1] |> int
        match isLineValid tokens[1] with
        | true -> gameNumber
        | false -> 0
        


    printfn "Reading files for day 2!"
    let fullPath = getFilePath "input2"
    let solve: string =
            
        
        let lines = System.IO.File.ReadLines(fullPath)
        Seq.iter (fun line -> printfn "%s" line) lines
        let sum = Seq.map (fun line -> checkLine line) lines |> Seq.sum

        printfn "Files read, solving"
        sum |> string
