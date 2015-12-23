

IF "%DIFF_EXE%" == "" (
set DIFF_EXE="C:\Program Files\Beyond Compare 4\BComp.exe"
)

%DIFF_EXE% SqlSkim.Driver.FunctionalTests\RulesTestData\Expected SqlSkim.Driver.FunctionalTests\RulesTestData\Actual /title1=Expected /title2=Actual