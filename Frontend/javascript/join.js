const joinForm = document.getElementById("join-form");
const errorMessage = document.getElementById("error-message");

joinForm.addEventListener("submit", handleSubmit);

async function handleSubmit(e) {
  e.preventDefault();
  errorMessage.innerText = "";

  const name = new FormData(joinForm).get("name");

  if (!name) {
    errorMessage.innerText = "Please enter your name to join a group.";
    return;
  }

  try {
    const response = await fetch("https://localhost:7120/api/Banana/join", {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify(name),
    });

    if (!response.ok) {
      errorMessage.innerText = "Failed to join, please try again.";
      return;
    }

    sessionStorage.setItem("name", name);
    sessionStorage.setItem("group", JSON.stringify(await response.json()));
    location.href = "/banana.html";
  } catch (e) {
    console.error(e);
  }
}
