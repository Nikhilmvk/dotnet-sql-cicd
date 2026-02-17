pipeline {
    agent any

    stages {

        stage('Deploy to Ubuntu VM') {
            steps {
                sshagent(['ubuntu-server']) {
                    bat '''
                    ssh -o StrictHostKeyChecking=no nikhil@192.168.17.134 ^
                    "rm -rf ~/app &&
                     git clone https://github.com/Nikhilmvk/dotnet-sql-cicd.git ~/app &&
                     cd ~/app &&
                     docker build -t dotnet-sql-ui-app . &&
                     docker stop dotnet-api || true &&
                     docker rm dotnet-api || true &&
                     docker run -d -p 5000:8080 --name dotnet-api dotnet-sql-ui-app"
                    '''
                }
            }
        }

    }
}
