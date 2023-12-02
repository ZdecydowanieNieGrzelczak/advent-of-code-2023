namespace Library
module day22 =
    open shared
    let maxRed = 12
    let maxGreen = 13
    let maxBlue = 14

    let getMaxToken (token: string, count: int * int * int)  =
        let tokens = token.Split(" ")
        let (r, g, b) = count
        let value = tokens[0] |> int
        match tokens[1] with
        | "green" -> if g > value then (r, g, b) else (r, value, b)
        | "red" -> if r > value then (r, g, b) else (value, g, b)
        | "blue" -> if b > value then (r, g, b) else (r, g, value)
        | _ -> printfn "Bad Token: %s" tokens[1]; failwith "Bad parsing of tokens!"

    let rec goThroughGame (remainingGames: List<string>, count: int * int * int) =
        match remainingGames with
        | head::tail -> goThroughGame (tail, (getMaxToken (head, count)))         
        | [] -> count

    let isGameValid (game: string) =
        let trimmedTokens = game.Split(",") |> Array.map(fun x -> x.Trim())
        goThroughGame (List.ofArray trimmedTokens, (0, 0, 0)) 

    let goThroughLine (line: string) =
        let games = line.Replace(';', ',')
        isGameValid games

    let checkLine (line: string) =
        let tokens = line.Split ":"
        let (r, g, b) = goThroughLine tokens[1]
        r * g * b        


    printfn "Reading files for day 2.2!"
    let fullPath = getFilePath("input2")
    let solve: string =
            
        
        let lines = System.IO.File.ReadLines(fullPath)
        Seq.iter (fun line -> printfn "%s" line) lines
        let sum = Seq.map (fun line -> checkLine line) lines |> Seq.sum

        printfn "Files read, solving"
        sum |> string
