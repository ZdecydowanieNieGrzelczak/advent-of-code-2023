namespace Library

open System.IO

module shared =
    let getFilePath filename = 
        let baseDirectory = __SOURCE_DIRECTORY__
        let baseDirectory' = Directory.GetParent(baseDirectory)
        let filePath = "Library/data/" + filename + ".txt"
        Path.Combine(baseDirectory'.FullName, filePath)