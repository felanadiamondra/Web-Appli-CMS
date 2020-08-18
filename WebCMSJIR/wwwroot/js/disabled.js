
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

function getJDE(data) {
    var element = document.getElementById("afficheJDE");
    element.innerHTML = data;
}

function AfficheJDE(str) {
    var xhr = creerInstance();
    xhr.onreadystatechange = function () {
        if (xhr.readyState == 4) {
            if (xhr.status == 200) {
                alert("Liste prête !")
                getJDE(xhr.responseText);
            }
            else {
                document.getElementById("afficheJDE").innerHTML = "Error: returned status code " + xhr.status + " " + xhr.statusText;
            }
        }
    };
    xhr.open("GET", "/Frequentation/AfficherJDE?matricule=" + str, true);
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

function Famille(nb) {
    var dates = new Date();
    var fullYear = dates.getFullYear();
    var nom = document.getElementsByTagName('TR')[nb].cells[4].textContent;
    var sexe = document.getElementsByTagName('TR')[nb].cells[5].textContent;
    var sa = document.getElementsByTagName('TR')[nb].cells[6].textContent;
    var datenais = document.getElementsByTagName('TR')[nb].cells[7].textContent;


    var usersYear = datenais.slice(6);
    console.log(usersYear);
    var age = fullYear - usersYear;
   

    document.getElementById('sexe').value = sexe;
    document.getElementById('nom').value = nom;
    document.getElementById('sa').value = sa;
    document.getElementById('datenais').value = datenais;
    document.getElementById('agePat').value = age;
}



        
    