<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:ec2="http://ec2.amazonaws.com/doc/2008-12-01/" exclude-result-prefixes="ec2">
    <xsl:output method="xml" omit-xml-declaration="no" indent="yes"/>
    <xsl:variable name="ns" select="'http://ec2.amazonaws.com/doc/2008-12-01/'"/>
    <xsl:template match="ec2:DescribeImagesResponse">
        <xsl:element name="DescribeImagesResponse" namespace="{$ns}">
            <xsl:element name="ResponseMetadata" namespace="{$ns}">
                <xsl:element name="RequestId" namespace="{$ns}">
                    <xsl:value-of select="ec2:requestId"/>
                </xsl:element>
            </xsl:element>
            <xsl:element name="DescribeImagesResult" namespace="{$ns}">
                <xsl:apply-templates select="ec2:imagesSet"/>
            </xsl:element>
        </xsl:element>
    </xsl:template>
    <xsl:template match="ec2:imagesSet">
        <xsl:for-each select="ec2:item">
            <xsl:element name="Image" namespace="{$ns}">
                <xsl:element name="ImageId" namespace="{$ns}">
                    <xsl:value-of select="ec2:imageId"/>
                </xsl:element>
                <xsl:element name="ImageLocation" namespace="{$ns}">
                    <xsl:value-of select="ec2:imageLocation"/>
                </xsl:element>
                <xsl:element name="ImageState" namespace="{$ns}">
                    <xsl:value-of select="ec2:imageState"/>
                </xsl:element>
                <xsl:element name="OwnerId" namespace="{$ns}">
                    <xsl:value-of select="ec2:imageOwnerId"/>
                </xsl:element>
                <xsl:element name="Visibility" namespace="{$ns}">
                    <xsl:if test="ec2:isPublic = 'true'">Public
                    </xsl:if>
                    <xsl:if test="not(ec2:isPublic = 'true')">Private
                    </xsl:if>
                </xsl:element>
                <xsl:apply-templates select="ec2:productCodes"/>
                <xsl:element name="Architecture" namespace="{$ns}">
                    <xsl:value-of select="ec2:architecture"/>
                </xsl:element>
                <xsl:element name="ImageType" namespace="{$ns}">
                    <xsl:value-of select="ec2:imageType"/>
                </xsl:element>
                <xsl:element name="KernelId" namespace="{$ns}">
                    <xsl:value-of select="ec2:kernelId"/>
                </xsl:element>
                <xsl:element name="RamdiskId" namespace="{$ns}">
                    <xsl:value-of select="ec2:ramdiskId"/>
                </xsl:element>
                <xsl:element name="Platform" namespace="{$ns}">
                    <xsl:value-of select="ec2:platform"/>
                </xsl:element>
            </xsl:element>
        </xsl:for-each>
    </xsl:template>
    <xsl:template match="ec2:productCodes">
        <xsl:for-each select="ec2:item">
            <xsl:element name="ProductCode" namespace="{$ns}">
                <xsl:value-of select="ec2:productCode"/>
            </xsl:element>
        </xsl:for-each>
    </xsl:template>
</xsl:stylesheet>
