(function () {
    var docModel = {
        filePath: '',
        content: ''
    };

    var textArea = document.getElementsByTagName('textarea')[0];
    var statusBar = document.getElementById('status-bar');

    document.getElementById('btn-open').addEventListener('click', function () {
        var result = window.external.openFile();
        if (result == null) return;

        docModel.filePath = result.filePath;
        docModel.content = result.content;
        textArea.value = docModel.content;
        statusBar.textContent = docModel.filePath;
    });

    document.getElementById('btn-save').addEventListener('click', function () {
        docModel.content = textArea.value;
        var result = window.external.saveFile(docModel);
        if (result == null) return;

        docModel.filePath = result.filePath;
        statusBar.textContent = docModel.filePath;
    });

    // Disable context menu.
    document.body.addEventListener('contextmenu', function (e) {
        if (e.target.tagName == 'TEXTAREA') return;
        e.preventDefault();
    });

    // If you want to catch all of unhandled exception, you can do that by wiring `window.onerror` event handler.
    //window.onerror = function (message, url, lineNumber, columnNumber, exception) {
    //    exception = exception || { message: message, stack: (url || '- unknown souce file -') + "(" + lineNumber + ":" + columnNumber + ")" };
    //};
})();