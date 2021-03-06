$(document).ready(function () {
  ///Please, type here Api's base URL.
  localStorage.setItem("BaseUrl", "https://localhost:44326");

  getAllPosts();
  validateSession();

  $(".witerUser").css({ display: "none" });
  $(".editorUser").css({ display: "none" });
});

function getAllPosts() {
  var baseUrl = localStorage.getItem("BaseUrl");
  var listPost = "";

  $.get(`${baseUrl}/api/Posts/GetAllPosts`, function (response) {
    if (response) {
      response.map((x) => {
        listPost += drawPost(x, "Posts");
      });
      $("#posts").html(listPost);
    }
  });
}

function login() {
  var baseUrl = localStorage.getItem("BaseUrl");
  var parameters = {
    userName: $("#txtUserName").val(),
    password: $("#txtPassword").val(),
  };

  var data = JSON.stringify(parameters);

  $.ajax({
    type: "POST",
    contentType: "application/json",
    datatype: "json",
    url: `${baseUrl}/api/Users/GetUser`,
    data: data,
  })
    .done(function (result) {
      if (result) {
        localStorage.setItem("user", JSON.stringify(result));
        $("#spanName").text(result.name);

        $("#loging").css({ display: "none" });

        validRolUser();
      } else {
        alert("Invalid User");
      }
    })
    .fail(function () {
      alert("error");
    });
}

function validRolUser() {
  var user = JSON.parse(localStorage.getItem("user"));
  console.log(user);
  if (user.rolId == 1) {
    $(".witerUser").css({ display: "" });
  } else {
    $(".editorUser").css({ display: "" });
  }
}

function validateSession() {
  if (localStorage.getItem("User")) {
    console.log("hay usuario");
  } else {
    console.log("nooooooooooooooo hay");
  }
}

function getPendingPost() {
  var baseUrl = localStorage.getItem("BaseUrl");

  var listPost = "";

  $.get(`${baseUrl}/api/Posts/GetPendingPosts`, function (response, status) {
    if (response) {
      response.map((x) => {
        listPost += drawPost(x, "Editor");
      });
      $("#pendingPosts").html(listPost);
    } else if (status == "nocontent") {
      $("#pendingPosts").html(listPost);
    }
  });
}

function savePost() {
  var baseUrl = localStorage.getItem("BaseUrl");
  var parameters = {
    id: 0,
    creationDate: "2021-03-05T01:46:39.573Z",
    titlePost: $("#titlePost").val(),
    postText: $("#postText").val(),
    user: JSON.parse(localStorage.getItem("user")),
    state: { id: 1, name: "" },
  };
  var data = JSON.stringify(parameters);

  $.ajax({
    type: "POST",
    contentType: "application/json",
    datatype: "json",
    url: `${baseUrl}/api/Posts/CreatePost`,
    data: data,
  })
    .done(function (result) {
      console.log(result);
      $("#btnLaunchModal").trigger("click");

      $("#postText").val("");
      $("#titlePost").val("");

      $("#messageModal").text("Post Saved succesfully");
    })
    .fail(function () {
      console.log("error");
    });
}

function approvePost(event) {
  var baseUrl = localStorage.getItem("BaseUrl");
  var parameters = {
    idPost: Number(event.target.id),
    idState: 2,
  };

  var data = JSON.stringify(parameters);

  $.ajax({
    type: "POST",
    contentType: "application/json",
    datatype: "json",
    url: `${baseUrl}/api/Posts/ApproveReject`,
    data: data,
  })
    .done(function (result) {
      if (result) {
        getPendingPost();
      } else {
        alert("There is an error");
      }
    })
    .fail(function () {
      console.log("error");
    });
}

function rejectPost(event) {
  var baseUrl = localStorage.getItem("BaseUrl");
  var parameters = {
    idPost: Number(event.target.id),
    idState: 3,
  };

  var data = JSON.stringify(parameters);

  $.ajax({
    type: "POST",
    contentType: "application/json",
    datatype: "json",
    url: `${baseUrl}/api/Posts/ApproveReject`,
    data: data,
  })
    .done(function (result) {
      console.log(result);
      getPendingPost();
    })
    .fail(function () {
      console.log("error");
    });
}

function logOut() {
  location.reload();
}

function saveComment(event) {
  var id = event.target.id;
  var comment = $("#txtArea" + id).val();

  var baseUrl = localStorage.getItem("BaseUrl");
  var parameters = {
    postId: Number(id),
    detail: comment,
  };

  var data = JSON.stringify(parameters);

  $.ajax({
    type: "POST",
    contentType: "application/json",
    datatype: "json",
    url: `${baseUrl}/api/Posts/SaveComment`,
    data: data,
  })
    .done(function (result) {
      if (result) {
        getAllPosts();
      } else {
        alert("error");
      }
    })
    .fail(function () {
      console.log("error");
    });
}

function drawPost(data, mode = "") {
  var result = "";

  switch (mode) {
    case "Editor":
      result = `<div class="accordion accordion-flush" id="accordionFlushExample">
                <div class="accordion-item">
                    <h2 class="accordion-header" id="flush-headingOne">
                    <button class="accordion-button collapsed" type="button" data-bs-toggle="collapse" data-bs-target="#flush-collapse${data.id}" aria-expanded="false" aria-controls="flush-collapse${data.id}">
                    ${data.titlePost}
                    </button>
                    </h2>
                    <div id="flush-collapse${data.id}" class="accordion-collapse collapse" aria-labelledby="flush-headingOne" data-bs-parent="#accordionFlushExample">
                        <div class="accordion-body">
                        
                        <div class="card">
                            <div class="card-header">
                                ${data.user.name}
                                <br>
                                <span>Creation Date: ${data.creationDate}</span>
                            </div>
                            <div class="card-body">
                                <h5 class="card-title">${data.titlePost}</h5>
                                <p class="card-text">${data.postText}</p>                        
                                <a href="#" class="btn btn-success approvePost" onclick="approvePost(event)" id="${data.id}">Approve</a>/
                                <a href="#" class="btn btn-danger approvePost"   onclick="rejectPost(event)" id="${data.id}" >Reject</a>
                            </div>
                        </div>

                        </div>
                    </div>
                </div>
                </div>`;
      break;

    case "Posts":
      var comments = "";
      data.comments.map((x) => {
        comments += `<p class="font-weight-light comments"> ${x.detail}</p>`;
      });

      result = `
          <div class="accordion accordion-flush" id="accordionFlushExample">
          <div class="accordion-item">
              <h2 class="accordion-header" id="flush-headingOne">
              <button class="accordion-button collapsed" type="button" data-bs-toggle="collapse" data-bs-target="#flush-collapse${data.id}" aria-expanded="false" aria-controls="flush-collapse${data.id}">
              ${data.titlePost}
              </button>
              </h2>
              <div id="flush-collapse${data.id}" class="accordion-collapse collapse" aria-labelledby="flush-headingOne" data-bs-parent="#accordionFlushExample">
                  <div class="accordion-body">
                  
                  <div class="card">
                      <div class="card-header">
                          ${data.user.name}
                          <br>
                          <span>Creation Date: ${data.creationDate}</span>
                      </div>
                      <div class="card-body">
                          <h5 class="card-title">${data.titlePost}</h5>
                          <p class="card-text">${data.postText}</p>                        
                          <br>
                          <div id="comment" >
                            <div class="input-group">
                              <span class="input-group-text">Comment</span>
                              <textarea class="form-control" aria-label="With textarea" id="txtArea${data.id}"></textarea>
                            </div>
                            <div >
                              <a id="${data.id}" href="#" class="btn btn-primary btn-lg" onclick="saveComment(event)">Save Comment</a>
                            </div>

                            <div id="commentsSaved" class="form col-md-12"> ${comments}</div>

                          </div>
                      </div>
                  </div>

                  </div>
              </div>
          </div>
          </div>`;
      break;
  }

  return result;
}
