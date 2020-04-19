node{
	stage('Build Docker Image'){
	sh 'docker build -t basaveswarrao/demo_app:1 .'
	}
	stage('push Docker Image'){
	withCredentials([string(credentialsId: 'Dockerhubpwd', variable: 'Dockerhubpwd')]) {
    sh "docker login -u basaveswarrao -p ${Dockerhubpwd}"
}
	sh 'docker push basaveswarrao/demo_app:1'
	}
}
