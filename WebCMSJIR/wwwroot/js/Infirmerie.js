function getPatient(nbr) {
    const freqmala = document.getElementsByTagName('TR')[nbr].cells[1].textContent;
    const nom = document.getElementsByTagName('TR')[nbr].cells[3].textContent;
    const age = document.getElementsByTagName('TR')[nbr].cells[4].textContent;
    const sexe = document.getElementsByTagName('TR')[nbr].cells[5].textContent;
    const prest = document.getElementsByTagName('TR')[nbr].cells[7].textContent;

    document.getElementById('idPat').value = freqmala;
    document.getElementById('nomPat').value = nom;
    document.getElementById('agePat').value = age;
    document.getElementById('sexePat').value = sexe;
    document.getElementById('prestPat').value = prest;
}