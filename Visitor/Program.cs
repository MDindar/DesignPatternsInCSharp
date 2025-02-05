// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");


var zoo = new Zoo();
zoo.Add(new Lion("lion1"));
zoo.Add(new Elephant("elephant1"));
zoo.Add(new Elephant("elephant2"));
zoo.Add(new Parrot("parrot1"));
zoo.Add(new Parrot("parrot2"));
zoo.Add(new Parrot("parrot3"));
var vet = new Vet("Dr. Smith");
var monitor = new PerformanceMonitorVisitor(vet);
zoo.AcceptVisitor(monitor);
monitor.PrintPerformance();
zoo.AcceptVisitor(new Trainer("Mr. Joe"));
var reporter = new ReporterVisitor();
zoo.AcceptVisitor(reporter);
reporter.DisplayReport();
