function uploadFile() {
    const fileInput = document.getElementById("fileInput");
    const jsonOutput = document.getElementById("jsonOutput");  
    
    if (fileInput.files.length === 0) {
      alert("Por favor, selecione um arquivo de texto.");
      return;
    }
  
    const file = fileInput.files[0];
    const reader = new FileReader(); 
    
    reader.onload = function (e) {
      const content = e.target.result;
      const jsonData = createJSON(btoa(content));  
      
      jsonOutput.innerHTML = "<pre>" + JSON.stringify(jsonData, null, 2) + "</pre>";
  
      // Simula a chamada da API C# com o JSON gerado
      callAPIImportacao(jsonData, postUploadActionSuccess, postUploadActionError);
    };
  
    reader.readAsText(file);
  }

  function postUploadActionSuccess(response) {

  }

  function postUploadActionError(response) {

  }
  
  function createJSON(content) {    
    const data = {
      content: content.trim()
    };
  
    return data;
  }
  
  function callAPIImportacao(jsonData, onSuccess, onError) {
    // Aqui você pode fazer a chamada da API C# usando o JSON gerado
    // Substitua este código pela lógica real de chamada da API
    console.log("Chamada da API C# com o JSON:");
    console.log(jsonData);
  }