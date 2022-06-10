# Employees

Проект создан на WPF .NET Framework 4.7.2. Для хранения данных был выбран SQL Server.


Чтобы запустить программу, нужно создать базу данных (я использовал Microsoft SQL Server Management Studio). 
В файле App.config нужно добавить строку подключения:
<connectionStrings>
		<add name="EmployeesConnection" connectionString="Data Source="здесь название базы данных, которую вы создали";Initial Catalog=gr691_mnm;Integrated Security=True;" providerName="System.Data.SqlClient" />
</connectionStrings>
Также нужно установить EntityFramework для работы с БД и FluentValidation для валидации
Далее нужно выполнить миграцию. Для этого нужно открыть package management console и написать следующие команды:
Enable-migrations
Add-migration "название миграции"
Update-database
Программа готова к запуску
При первом запуске будут добавлены данные в таблицу Post
