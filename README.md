# TextGenerator
Text helper generate

Install from NUGET https://www.nuget.org/packages/CodeMaze.TextGenerator

    Install-Package CodeMaze.TextGenerator

Include package into your project 
                
    using CodeMaze.TextGenerator;
          
Builder random text
    
    TextGenerator.Builder(size) -- [size] type integer
    
Builder text with options:
    
    TextGenerator.TextBuilder(size, text_type)  -- [size] type integer, text_type type enum with many options
        
    TextType
    {
        TextRandom,
        TextUperCase,
        TextLowerCase,
        Numbers
    }
    
Builder more text type:
    
    TextGenerator.KeygenBuilder(keygen_type) -- text length follow type input
    
    KeygenType
    {
        MemorablePassword,
        StrongPassword,
        FortKnoxPassword,
        CodeIgniterEncrytion,
        WPA_160bit,
        WPA_504bit,
        WEP_64bit,
        WEP_128bit,
        WEP_152bit,
        WEP_256bit,
    }
