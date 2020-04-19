pipeline {
    agent any
    stages {
        stage('DockerBuild') {
            steps {
               sh "docker build -t demoapp:B${BUILD_NUMBER} ."
            }
        }
    }
}
