using FizzBuzzMuzz;

// services initialization

var validator = new NumberValidator();

var firstTransformer = new TransformerBuilder()
    .AddMultiplier(3).WithReplacement("fizz")
    .AddMultiplier(5).WithReplacement("buzz")
    .Build();

var secondTransformer = new TransformerBuilder()
    .AddMultiplier(3).WithReplacement("fizz")
    .AddMultiplier(5).WithReplacement("buzz")
    .AddMultiplier(4).WithReplacement("muzz")
    .AddMultiplier(7).WithReplacement("guzz")
    .Build();

var thirdTransformer = new TransformerBuilder()
    .AddMultiplier(3).AddMultiplier(5).WithReplacement("good-boy")
    .AddMultiplier(3).IsExclusive().WithReplacement("dog")
    .AddMultiplier(5).IsExclusive().WithReplacement("cat")
    .AddMultiplier(3).WithReplacement("fizz")
    .AddMultiplier(5).WithReplacement("buzz")
    .AddMultiplier(4).WithReplacement("muzz")
    .AddMultiplier(7).WithReplacement("guzz")
    .AddValidator(validator)
    .Build();

var tokenizer = new CommasTokenizer();
var transformer = new FizzBuzzSequenceTransformer(thirdTransformer, tokenizer);

var userIO = new ConsoleUserIOProcessor();

// main

var input = userIO.GetInput("Please, enter a number sequence:");
var result = transformer.Transform(input);
userIO.Output(result, "Transformed sequence:");
