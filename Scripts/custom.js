var vhub = $.connection.releaseStatusHub;

(function () {

    vhub.client.showLiveResult = function (data) {
        var response = $.parseJSON(data);
        bindDeploymentStatusToTextBoxes(response);
    };

    $.connection.hub.start();
    getTeamsReleaseStatus();

}());

function getTeamsReleaseStatus() {

    $.ajax({
        url: 'home/getteamsreleasestatus', // HomeController action to get data on page load
        dataType: 'json',
        success: function (response) {
            bindDeploymentStatusToTextBoxes(response);
        }.bind(this),
        error: function (xhr, status, err) {
            console.log(error);
        }.bind(this)
    });

}

// this function is called on "oninput" event for the text box
function updateDeploymentStatus(teamMemberName, deploymentStatus) {

    $.connection.hub.start().done(function () {
        // Call the Send method on the hub.
        vhub.server.send(teamMemberName, deploymentStatus);
    });
}

function bindDeploymentStatusToTextBoxes(teamsData) {
    document.getElementById("txtKajal").value = teamsData[0]["kajal"];
    document.getElementById("txtKadharbhi").value = teamsData[1]["kadharbhi"];
    document.getElementById("txtKadharbhiShaik").value = teamsData[2]["kadharbhishaik"];
}
