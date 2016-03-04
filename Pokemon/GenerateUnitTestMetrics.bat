"%~dp0..\packages\OpenCover.4.6.519\OpenCover.Console.exe" ^
-register:user ^
-target:"%VS140COMNTOOLS%\..\IDE\mstest.exe" ^
-targetargs:"/testcontainer:\"%~dp0..\PokemonTests\bin\Debug\PokemonTests.Tests.dll\" /resultsfile:\"%~dp0BowlingSPAService.trx\"" ^
-filter:"+[BowlingSPAService*]* -[BowlingSPAService.Tests]* -[*]BowlingSPAService.RouteConfig" ^
-mergebyhash ^
-skipautoprops ^
-output:"%~dp0\GeneratedReports\BowlingSPAServiceReport.xml"