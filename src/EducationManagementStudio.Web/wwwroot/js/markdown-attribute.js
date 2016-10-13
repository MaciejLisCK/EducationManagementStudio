; (function () {
    applyLineMarkdown();
    applyContentMarkdown();
    applyContentTrimMarkdown();

    function applyLineMarkdown() {
        var lineRenderer = new marked.Renderer();
        lineRenderer.paragraph = function (text, level) { return text; }
        markedLineOptions = { renderer: lineRenderer };

        var markdownLineElements = document.querySelectorAll("[data-markdown='line']");
        for (var i = 0; i < markdownLineElements.length; i++) {
            var markdownLineElement = markdownLineElements[i];
            var markdownLineElementContent = markdownLineElement.innerHTML;
            var markdownLineElementContentProcessed = marked(markdownLineElementContent, markedLineOptions);
            markdownLineElement.innerHTML = markdownLineElementContentProcessed;
        }
    }

    function applyContentMarkdown() {
        var markdownContentElements = document.querySelectorAll("[data-markdown='content']");
        for (var i = 0; i < markdownContentElements.length; i++) {
            var markdownContentElement = markdownContentElements[i];
            var markdownContentElementContent = markdownContentElement.innerHTML;
            var markdownContentElementContentProcessed = marked(markdownContentElementContent);

            markdownContentElement.innerHTML = markdownContentElementContentProcessed;
        }
    }

    function applyContentTrimMarkdown() {
        var markdownContentElements = document.querySelectorAll("[data-markdown='content-trim']");
        for (var i = 0; i < markdownContentElements.length; i++) {
            var markdownContentElement = markdownContentElements[i];
            var markdownContentElementContent = markdownContentElement.innerHTML.trim();
            var markdownContentElementContentProcessed = marked(markdownContentElementContent);

            markdownContentElement.innerHTML = markdownContentElementContentProcessed;
        }
    }
})();