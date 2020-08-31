
//instanciation d'objet xhr
function creerInstance() {
    var req = null;
    if (window.XMLHttpRequest) {
        req = new XMLHttpRequest();
    } else if (window.ActiveXObject) {
        try {
            req = new ActiveXObject("Msxml2.XMLHTTP");
        } catch (e) {
            try {
                req = new ActiveXObject("Microsoft.XMLHTTP");
            } catch (e) {
                alert("XHR not created");
            }
        }
    }
    return req;
}

function plusPrest(data) {
    var element = document.getElementById('afficherPrest');
    element.innerHTML = data;
}
 
function ListePrest(activite) {
    var xhr = creerInstance();
    xhr.onreadystatechange = function () {
        if (xhr.readyState == 4) {
            if (xhr.status == 200) {
                plusPrest(xhr.responseText);
            }
            else {
                document.getElementById('afficherPrest').innerHTML = "Error: returned status code= " + xhr.status + " " + xhr.statusText;
            }
        }
    }
    xhr.open("GET", "/Frequentation/Prestation?codeAct=" + activite, true);
    xhr.send();
}

function getMed(data) {
    var element = document.getElementById("afficheMed");
    element.innerHTML = data;
}

function ListeMed(str) {
    var xhr = creerInstance();
    xhr.onreadystatechange = function () {
        if (xhr.readyState == 4) {
            if (xhr.status == 200) {
                getMed(xhr.responseText);
            }
            else {
                document.getElementById("afficheMed").innerHTML = "Error: returned status code " + xhr.status + " " + xhr.statusText;
            }
        }
    };
    xhr.open("GET", "/Frequentation/AfficherMed?codePrest=" + str, true);
    xhr.send();
}



//Ajouter type societe
function gettype(data) {
    var element = document.getElementById("afficheType");
    element.innerHTML = data;
}

function AfficheType(str) {
    var xhr = creerInstance();
    xhr.onreadystatechange = function () {
        if (xhr.readyState == 4) {
            if (xhr.status == 200) {
                gettype(xhr.responseText);
            }
            else {
                document.getElementById("afficheType").innerHTML = "Error: returned status code " + xhr.status + " " + xhr.statusText;
            }
        }
    };
    xhr.open("GET", "/Frequentation/AfficherTypeSTE?codeSte=" + str, true);
    xhr.send();
}

//Calcul Numero patient
function getNum(data) {
    var element = document.getElementById("affichageNum");
    element.innerHTML = data;
}

function CompteNum(str) {
    var xhr = creerInstance();
    xhr.onreadystatechange = function () {
        if (xhr.readyState == 4) {
            if (xhr.status == 200) {
                getNum(xhr.responseText);
            }
            else {
                document.getElementById("affichageNum").innerHTML = "Error: returned status code " + xhr.status + " " + xhr.statusText;
            }
        }
    };
    xhr.open("GET", "/Frequentation/AfficherNumero?codeMed=" + str, true);
    xhr.send();
}



        
    