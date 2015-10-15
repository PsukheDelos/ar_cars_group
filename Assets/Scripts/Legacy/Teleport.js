var target :Transform;

function Update() {
}

function OnTrigger (col : Collider) {
if(col.gameObject.tag == "teleportxx") {
this.transform.position = target.position;
}
}