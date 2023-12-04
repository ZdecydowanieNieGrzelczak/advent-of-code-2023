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
        List.map (fun c -> matchCharWithSymbol c) indexes |> List.contains true

        
    let getIndexToCheck (line: string, index: int) =
        match index with
        | 0 -> [ line[0]; line[1]];
        | x when x = (line.Length - 1) -> printfn "final char"; [line[x]; line[x - 1]]
        | y -> [line[y - 1]; line[y]; line[y + 1]]

    let checkAllTheNeighbours (lines: List<string>, index: int) = function
        // Terminate early if already found
        | true -> true
        | false -> List.map (fun line -> checkForSymbols(getIndexToCheck(line, index))) lines |> List.contains true

    let rec checkLineInput (line: string, prev: string, next: string, current: Option<string>, valid: bool, index: int, sum: int) =
        if index = line.Length 
            then match current with
                    | None -> sum
                    | Some x -> sum + (x |> int)
            else
                match line[index] with
                | x when charIsDigit x -> 
                    let newCurrent = 
                        match current with
                        | Some cur -> Some (cur + string x)
                        | None -> Some (string x)
                    checkLineInput(line, prev, next, newCurrent, valid || checkAllTheNeighbours([prev; line; next], index) valid, index + 1, sum)
                | _ -> match valid with
                            | false -> checkLineInput(line, prev, next, None, false, index + 1, sum)
                            | true -> match current with
                                        | Some x -> checkLineInput(line, prev, next, None, false, index + 1, sum + (x |> int))
                                        | None -> checkLineInput(line, prev, next, None, false, index + 1, sum)


    let rec parseInput (input: List<string>, prev: Option<string>, current: Option<string>, sum: int) =
        match input with
            | [] -> sum
            | head::tail -> match current with
                            | None -> parseInput(tail, None, Some(head), sum)
                            | Some currentVal -> match prev with
                                                    | None -> parseInput(tail, current, Some(head), sum)
                                                    | Some prevVal -> parseInput(tail, current, Some(head), sum + checkLineInput(currentVal, prevVal, head, None, false, 0, 0) )


    let solve: string =
        let fullPath = getFilePath "input3"
        let lines = System.IO.File.ReadLines(fullPath)
        let paddingBlock = System.String.Concat([ for i in 1..(Seq.head lines).Length -> '.'])
        let paddedLines = string paddingBlock :: (List.ofSeq lines) @ [string paddingBlock]
        List.iter (fun x -> printfn "%s" x) paddedLines
        sprintf "%i" (parseInput(paddedLines, None, None, 0))

