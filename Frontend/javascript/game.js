const banana = document.getElementById("banana");
const counter = document.getElementById("counter");
const greeting = document.getElementById("greeting");

const group = JSON.parse(sessionStorage.getItem("group"));
const name = sessionStorage.getItem("name");

if (!group || !name) {
  location.href = "/";
}

greeting.innerText = `Welcome, ${name} in group ${group.id}`;

setInterval(getCount, 100);

banana.addEventListener("click", updateCount);

async function getCount() {
  try {
    const response = await fetch(
      `https://localhost:7120/api/Banana/group/${group.id}`
    );
    const count = await response.json();

    counter.innerText = `count = ${count}`;
  } catch (e) {
    console.error(e);
  }
}

async function updateCount() {
  try {
    await fetch(`https://localhost:7120/api/Banana/group`, {
      method: "PUT",
      headers: {
        "Content-Type": "application/json",
      },
      body: group.id,
    });
  } catch (e) {
    console.error(e);
  }
}
