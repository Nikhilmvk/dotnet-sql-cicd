pipeline {
    agent any

    stages {
        stage('Checkout Code') {
            steps {
                checkout scm
            }
        }

        stage('Build Docker Image') {
            steps {
                sh 'docker build -t dotnet-sql-ui-app .'
            }
        }

        stage('Deploy') {
            steps {
                sh '''
                docker stop dotnet-api || true
                docker rm dotnet-api || true

                docker run -d -p 5000:8080 \
                  --name dotnet-api \
                  dotnet-sql-ui-app
                '''
            }
        }
    }
}
