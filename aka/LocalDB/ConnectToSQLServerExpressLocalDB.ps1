param([bool]$CreateNewDevelopmentInstance)

# just a helper script to help setup test DB, some IDEs and tools will do this for free.

$lineSeparator = "-----------------------------------------------------------"
SqllocalDB.exe i
Write-Output $lineSeparator

if($CreateNewDevelopmentInstance) {
    SqlLocalDB.exe create "DEVELOPMENT" -s
}

SqllocalDB.exe i $result
Write-Output $lineSeparator
SqllocalDB.exe s

# for more info doing this in rider, see https://www.jetbrains.com/help/rider/Connecting_to_SQL_Server_Express_LocalDB.html#step-4-enter-credentials-and-test-your-connection