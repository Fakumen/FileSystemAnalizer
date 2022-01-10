# FileSystemAnalyzer
1. Название проекта: File System Analyzer
2. Студенты-участники:
    * Орлов Илья Вячеславович РИ-390015
    * Матвеев Фёдор Георгиевич РИ-390003
    * Лаптев Денис Александрович РИ-390004
    * Гарнышев Дмитрий Александрович РИ-390001
3. Проблема, которую решает проект:
    * Пользователю необходимо просканировать файловую систему и определить вес папок и файлов в ней.
4. Описание основных компонентов, из которых состоит проект:
    * [Домен] IFileSystemScanData - обобщающий интерфейс для IFileScanData и IFolderScanData, которые хранят в себе информацию о просканированных файлах и папках
    * [Приложение] IScanDataNode - обобщающий интерфейс для IFileDataNode и IFolderDataNode, интерфейсы, представляющие ноды дерева с данными IFileSystemScanData. Реализации этих интерфейсов должен предоставлять UI
    * [Приложение] AnalyzerApp - содержит методы, выполняющиеся при нажатии кнопок, на которые UI перенаправляет свои ивенты. В конструкторе требует
      * [Приложение] Scanner - умеет сканировать конкретные реализации интерфейсов IFolderScanData, с помощью заданной фабрики
      * [Приложение] IScanDataTreeBuilder - интерфейс, реализуемый конкретным UI, должен уметь строить дерево с информацией о папках
      * [Приложение] IScanDataInspector - интерфейс, реализуемый конкретным UI, должен уметь показывать детальную информацию о папке/файле
    * [UI] Класс формы - перенаправляет нажатия кнопок на ScannerApp 
    * [Точка сбора] Program - сборка зависимостей с помощью DI и запуск формы
5. Краткое описание точек расширения:
    * Сортировка по разным параметрам (SortNodesBy, SortNodesByDescending) - [IScanDataTreeBuilder](https://github.com/Fakumen/FileSystemAnalizer/blob/main/FileSystemAnalizer/App/Interfaces/IScanDataTreeBuilder.cs)
    * Фильтрация выходных данных на делегировании (селектор у Build()) - [IScanDataTreeBuilder](https://github.com/Fakumen/FileSystemAnalizer/blob/main/FileSystemAnalizer/App/Interfaces/IScanDataTreeBuilder.cs)
