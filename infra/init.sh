#!/bin/bash

# Function to setup hosts
setup_hosts() {
    local HOST_IP="127.0.0.1"
    local DOMAINS=("auth.local" "postgres.local" "pgadmin.local" "rabbit.local" "mail.local" "api.local")

    for DOMAIN in "${DOMAINS[@]}"; do
        local HOST_ENTRY="$HOST_IP $DOMAIN"

        if ! grep -q "$DOMAIN" /etc/hosts; then
            echo "Adding $DOMAIN to your /etc/hosts";
            sudo -- sh -c -e "echo '$HOST_ENTRY' >> /etc/hosts";

            if [ $? -ne 0 ]; then
                echo "Failed to add $DOMAIN to /etc/hosts";
            else
                echo "$DOMAIN added successfully";
            fi
        else
            echo "$DOMAIN already exists in /etc/hosts";
        fi
    done
}

# Function to install mkcert
install_mkcert() {
    if ! command -v mkcert &> /dev/null; then
        echo "mkcert could not be found, installing..."
        if [[ "$OSTYPE" == "linux-gnu"* ]]; then
            sudo apt-get install libnss3-tools
            curl -L https://github.com/FiloSottile/mkcert/releases/download/v1.4.3/mkcert-v1.4.3-linux-amd64 -o mkcert
            chmod +x mkcert
            sudo mv mkcert /usr/local/bin/
        elif [[ "$OSTYPE" == "darwin"* ]]; then
            brew install mkcert
        else
            echo "Unsupported OS for automatic installation"
            return 1
        fi
    fi

    mkcert -install
    return 0
}

# Function to generate a wildcard certificate
generate_certificate() {
    local cert_name="local"
    if [ ! -f "${cert_name}.pem" ] || [ ! -f "${cert_name}-key.pem" ]; then
        mkcert -cert-file "certs/${cert_name}.pem" -key-file "certs/${cert_name}-key.pem" "*.local" localhost 127.0.0.1 ::1
        echo "Certificate and key have been generated with names ${cert_name}.pem and ${cert_name}-key.pem"
    else
        echo "Certificate already exists."
    fi
}

# Main script execution
setup_hosts
if install_mkcert; then
    generate_certificate
else
    echo "mkcert installation failed"
fi
