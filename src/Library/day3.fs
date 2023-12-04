namespace Library
module day3 =
    open shared

    let getNumbersFromTheLine (line: string) =
        line.Split('.') |> Array.filter (fun token -> token <> "")

    let charIsDigit (c: char) =
        let digitChar = int c - int '0'
        digitChar >= 0 && digitChar <= 9
    
    let matchCharWithSymbol = function
        | '.' -> false
        | c when charIsDigit c -> false
        | _ -> true

    let checkForSymbols (indexes: List<char>) = 
        List.forall (fun c -> matchCharWithSymbol c) indexes

        

    let getIndexToCheck (line: string, index: int) =
        match index with
        | 0 -> [ line[0]; line[1]];
        | x when x = (line.Length - 1) -> [line[x]; line[x - 1]]
        | y -> [line[y - 1]; line[y]; line[y + 1]]

    let checkAllTheNeighbours (lines: List<string>, index: int) = function
        // Terminate early if already found
        | true -> true
        | false -> List.forall (fun line -> checkForSymbols(getIndexToCheck(line, index))) lines

    let checkLineInput (line: string, prev: string, next: string, current: Option<string>, valid: bool, index: int) =
        match line[index] with
        | '.' -> current, valid
        | x when charIsDigit x -> 
            let newCurrent = 
                match current with
                | Some cur -> Some (cur + string x)
                | None -> Some (string x)
            newCurrent, checkAllTheNeighbours([prev; line; next], index) valid
        | _ -> current, true 


    let parseLine (previous: string, current: string, next: string) =
        // for i in 0..current.Length


        21

    let rec parseBlocks (remainer: List<string>, sum: int, previous: string, current: string) =
        match remainer with
        | [] -> sum
        | head::tail -> parseBlocks (tail, sum + (parseLine (previous, current, head)), current, head)

    let solve: string =
        let fullPath = getFilePath "input3"
        let lines = System.IO.File.ReadLines(fullPath)
        Seq.iter (fun line -> printfn "%A" (parseLine line)) lines
        // Seq.map (fun line -> line) lines 


        printfn "Files read, solving"

        "not solved yet"
