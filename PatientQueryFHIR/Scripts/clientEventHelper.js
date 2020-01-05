function downloadResults() {
//Grab the contents of the results div and allow the
 //user to download them.
    var content = $("#results").text();

    // https://www.websparrow.org/web/how-to-create-and-save-text-file-in-javascript
    var blob = new Blob([content],
        { type: "text/plain;charset=utf-8" });

    saveAs(blob, "PattientQueryResults.txt");




}